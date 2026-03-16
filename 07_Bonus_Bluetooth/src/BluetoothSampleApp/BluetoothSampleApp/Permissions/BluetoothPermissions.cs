namespace BluetoothSampleApp.Permissions;

/// <summary>
/// Custom permission definition for Bluetooth scanning (BLUETOOTH_SCAN on Android 12+).
/// </summary>
public class BluetoothScanPermission : Microsoft.Maui.ApplicationModel.Permissions.BasePlatformPermission
{
#if ANDROID
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
    [
#pragma warning disable CA1416 // Validate platform compatibility
        (Android.Manifest.Permission.BluetoothScan, true),
#pragma warning restore CA1416
    ];
#endif
}

/// <summary>
/// Custom permission definition for Bluetooth connecting (BLUETOOTH_CONNECT on Android 12+).
/// </summary>
public class BluetoothConnectPermission : Microsoft.Maui.ApplicationModel.Permissions.BasePlatformPermission
{
#if ANDROID
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
    [
#pragma warning disable CA1416 // Validate platform compatibility
        (Android.Manifest.Permission.BluetoothConnect, true),
#pragma warning restore CA1416
    ];
#endif
}

/// <summary>
/// Helper to request all Bluetooth-related permissions required at runtime.
/// </summary>
public static class BluetoothPermissionHelper
{
    /// <summary>
    /// Ensures all required Bluetooth permissions are granted. Throws if the user denies.
    /// </summary>
    public static async Task EnsurePermissionsAsync()
    {
#if ANDROID
        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.S)
        {
            // Android 12+: need BLUETOOTH_SCAN and BLUETOOTH_CONNECT
            await RequestPermissionAsync<BluetoothScanPermission>("Bluetooth Scan");
            await RequestPermissionAsync<BluetoothConnectPermission>("Bluetooth Connect");
        }
        else
        {
            // Android 11 and below: need location for BLE scanning
            await RequestPermissionAsync<Microsoft.Maui.ApplicationModel.Permissions.LocationWhenInUse>("Location");
        }
#elif IOS || MACCATALYST
        // iOS/macOS: Bluetooth permission is requested automatically by the system
        // when accessing CBCentralManager. No explicit request needed.
        await Task.CompletedTask;
#elif WINDOWS
        // Windows: No runtime permission needed for Bluetooth.
        await Task.CompletedTask;
#endif
    }

    private static async Task RequestPermissionAsync<TPermission>(string permissionName)
        where TPermission : Microsoft.Maui.ApplicationModel.Permissions.BasePermission, new()
    {
        var status = await Microsoft.Maui.ApplicationModel.Permissions.CheckStatusAsync<TPermission>();

        if (status == PermissionStatus.Granted)
            return;

        if (Microsoft.Maui.ApplicationModel.Permissions.ShouldShowRationale<TPermission>())
        {
            await Shell.Current.DisplayAlertAsync(
                "Permission Required",
                $"{permissionName} permission is required for Bluetooth functionality.",
                "OK");
        }

        status = await Microsoft.Maui.ApplicationModel.Permissions.RequestAsync<TPermission>();

        if (status != PermissionStatus.Granted)
        {
            throw new PermissionException($"{permissionName} permission was denied.");
        }
    }
}

