# Delete old version of API
Get-ChildItem -Path ./PV239_06_API/PV239_06_API.Core/Api/Generated -Include * -File -Recurse | ForEach-Object {$_.Delete()}

autorest --csharp --fluent --namespace="PV239_06_API.Core.Api" --override-client-name="ApiClient" --sync-methods="all" --client-side-validation="true" --input-file="http://localhost:5000/swagger/v1/swagger.json" --output-folder="./PV239_06_API/PV239_06_API.Core/Api"