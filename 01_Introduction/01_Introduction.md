---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
marp: true
---

<style>
    .container {
        display: flex;
    }

    .col {
        flex: 1
    }

    img[alt~="center"] {
    display: block;
    margin: 0 auto;
    }

    section.demo h1 {
        text-align: center;
        margin: 180px;
        font-size: 80px;
        color: rgb(132, 168, 196)
}

    /* Layout table variables */
    section.layout-table,
    section.layout-table-wrapped-header {
        --layout-table-spacing: 20px;
        --layout-table-header-font-size: 1.2em;
        --layout-table-header-padding: 15px 20px;
        --layout-table-cell-padding: 20px;
        --layout-table-img-width: 85%;
    }

    /* Shared table styling for layout slides */
    section.layout-table table,
    section.layout-table-wrapped-header table {
        width: 100%;
        border: none;
        border-collapse: separate;
        border-spacing: var(--layout-table-spacing) 0;
        background: transparent;
    }
    section.layout-table tbody,
    section.layout-table-wrapped-header tbody {
        background: transparent;
    }
    section.layout-table tr,
    section.layout-table-wrapped-header tr {
        background: transparent;
    }
    section.layout-table th,
    section.layout-table-wrapped-header th {
        text-align: center;
        font-size: var(--layout-table-header-font-size);
        font-weight: bold;
        padding: var(--layout-table-header-padding);
        white-space: normal;
        word-wrap: break-word;
    }
    section.layout-table td,
    section.layout-table-wrapped-header td {
        text-align: center;
        border: none;
        vertical-align: top;
        padding: var(--layout-table-cell-padding);
        background: transparent !important;
    }

    /* Default: single-line headers */
    section.layout-table td img {
        width: var(--layout-table-img-width);
        height: 400px;
        object-fit: contain;
    }

    /* Variant: wrapped headers need shorter images */
    section.layout-table-wrapped-header td img {
        width: var(--layout-table-img-width);
        height: 350px;
        object-fit: contain;
    }

    /* Layout grid for content presentation - 3 columns x 2 rows without headers */
    section.content-grid {
        --content-grid-spacing: 20px;
        --content-grid-img-height: 240px;
    }

    section.content-grid table {
        width: 100%;
        border: none;
        border-collapse: separate;
        border-spacing: var(--content-grid-spacing);
        background: transparent;
    }
    section.content-grid thead {
        display: none;
    }
    section.content-grid tbody {
        background: transparent;
    }
    section.content-grid tr {
        background: transparent;
    }
    section.content-grid tr:last-child td {
        padding-bottom: 20px;
    }
    section.content-grid td {
        text-align: center;
        border: none;
        vertical-align: middle;
        padding: 0;
        background: transparent !important;
        width: 33.33%;
    }
    section.content-grid td img {
        width: 100%;
        height: var(--content-grid-img-height);
        object-fit: contain;
    }
</style>

# PV239 – 01 Introduction

---

## Introduction

<!--
header: '**Introduction** &nbsp;&nbsp; .NET MAUI &nbsp;&nbsp; Setup &nbsp;&nbsp; Layouts &nbsp;&nbsp; Controls'
-->

- Roman
- Ondřej
- And what about you?

---

## Exercises

- Introduction
- Design – XAML
- Architecture – MVVM
- Architecture – IoC/DI
- Storage
- Networking – API
- Topic of your choice

---

## Goals

- Course organization
- Get in touch with .NET MAUI
- Go through environment setup
- Get to know available layouts and controls

---

## Course Organization

<div class='container'>
<div class='col'>

- Interactive syllabi – IS
- Materials & Resources
    - [Materials repository](https://github.com/jasho/pv239-maui)
    - [Sample app repository](https://github.com/jasho/cookbook-maui)
- Stream/recordings – [Youtube](https://www.youtube.com/playlist?list=PLMD3_JXajX1iWN-KFRie7esaE9NP7eBlf)
- Optional homeworks
- Project

</div>

<div class='col'>

- [Discord](https://discord.gg/HWs8rmT4bh)
![QR code with Discord server invite link](img/discord_invite_qr.png)

</div>
</div>

---

## Sample Application

- CookBook
- Android, iOS, Windows
- Communication with API
- Basic CRUD operations
- Saving of settings
- MVVM architecture
- Shell navigation

---

## "Standard" Application Development

<!--
header: 'Introduction &nbsp;&nbsp; **.NET MAUI** &nbsp;&nbsp; Setup &nbsp;&nbsp; Layouts &nbsp;&nbsp; Controls'
-->

![h:400 center](img/native_development.png)

---

## .NET Multi-platform App UI

![h:500 center](img/maui_overview.png)

---

## How it Works - Structure

- Platform specific frameworks
    - .NET for Android
    - .NET for iOS
    - .NET for MacOS
- Windows UI (WinUI) library
- Common BCL - .NET
- .NET Runtimes
    - Mono – Android, iOS, MacOS
    - WinRT/Win32 – Windows

---

## How it Works - UI

- Platform specific UI
    - Different platforms - different ways of defining UI
    - Can be defined separately using platform specific APIs
    - .NET for Android, .NET for iOS, .NET for MacOs, WinUI
- Common UI
    - Single framework for defining UI – mobile & desktop
    - XAML

---

## How it Works - Android

- C# compiles to intermediate language (IL)
- IL + JIT in app


![h:350 center](img/android_compilation.png)

---

## How it Works - iOS

- Fully ahead-of-time (AOT) compiled to native ARM binary

![h:350 center](img/ios_compilation.png)

---

## How it Works - macOS & Windows

- MacOS
    - Using Mac Catalyst
    - Apple’s solution to bring iOS Apps to desktop
    - Provides access to Mac OS APIs
- Windows
    - WinUI 3 library
    - Native apps and UWP

---

## How .NET MAUI Works

![h:500 center](img/maui_architecture.png)

---

## .NET MAUI

- Collection of Controls
- Layout engine for pages
- Navigation – pages, drawers
- Customizable handlers – enable platform specific controls
- APIs for native device features – GPS, accelerometer…
- Graphics library for 2D drawing code
- Single project, multi-targeting system
- .NET hot reload

---

<!--
header: 'Introduction &nbsp;&nbsp; .NET MAUI &nbsp;&nbsp; **Setup** &nbsp;&nbsp; Layouts &nbsp;&nbsp; Controls'
-->

## Setup

![h:500 center](img/maui_dev_tools.png)

---

## Visual Studio Workloads

![h:500 center](img/vs_workloads.png)

---

## iOS Development

- You need Mac Agent to compile the application
- Compilation runs on a Mac OS device
- Simulator and development can be done on Windows

---

## Create a New Project

![h:500 center](img/new_project_01.png)

---

## Create a New Project

![h:500 center](img/new_project_02.png)

---

## Create a New Project

![h:500 center](img/new_project_03.png)

---

## Create a New Project
<!-- _class: demo -->

# DEMO

---

## Project Structure
<style scoped>
section {
    font-size: 30px;
}
</style>

- One project for all platforms
- Shared code & resources (fonts, images, icons, splash screens…)
- Platforms folder:
    - Android – system colors, manifest
    - iOS – launch screen, Info.plist
    - Windows – package manifest, app manifest
    - Mac OS – Info.plist
    - Each platform
        - Application startup point
        - Custom handlers for application specific controls

---

## Layouts
<!-- _class: layout-table -->

| **AbsoluteLayout** | **RelativeLayout** | **FlexLayout** |
|:------------------:|:------------------:|:--------------:|
| ![](img/layouts_absolute-layout.png) | ![](img/layouts_relative-layout.png) | ![](img/layouts_flex-layout.png) |

---

## Layouts
<!-- _class: layout-table -->

| **Grid** | **StackLayout** |
|:--------:|:---------------:|
| ![](img/layouts_grid.png) | ![](img/layouts_stack-layout.png) |

---

## Layouts - StackLayout
<!-- _class: layout-table-wrapped-header -->

| **StackLayout** | **VerticalStackLayout** | **Horizontal<br>StackLayout** |
|:------------------:|:------------------:|:--------------:|
| ![](img/layouts_stack-layout.png) | ![](img/layouts_vertical-stack-layout.png) | ![](img/layouts_horizontal-stack-layout.png) |

---

## Grid

- Table-style layout
- RowDefinitions, ColumnDefinitions
    - Width / Height = 150 | * | Auto
- Grid.Row, Grid.Column – placement of control in the Grid
- Grid.RowSpan, Grid.ColumnSpan – control can span over multiple “cells”
- HorizontalSpacing, VerticalSpacing – empty space between “cells”

---

## StackLayout...

- HorizontalStackLayout, VerticalStackLayout
    - Individual layouts for single direction
    - Separate LayoutManagers with Measure methods
    - Recommended
- StackLayout
    - Wraps HorizontalStackLayout and VerticalStackLayout
    - Has Orientation
    - Useful for adaptive layouts

---

## Layouts
<!-- _class: demo -->

# DEMO

---

<!--
header: 'Introduction &nbsp;&nbsp; .NET MAUI &nbsp;&nbsp; Setup &nbsp;&nbsp; Layouts &nbsp;&nbsp; **Controls**'
-->

## Controls

![h:450 center](img/controls.png)

---

## Content Presentation
<!-- _class: content-grid -->

| | | |
|:--:|:--:|:--:|
| ![](img/content_presentation-label.png) | ![](img/content_presentation-image.png) | ![](img/content_presentation-box-view.png) |
| ![](img/content_presentation-web-view.png) | ![](img/content_presentation-map.png) |

---

## Actionable Controls

![h:500 center](img/actionable_controls.png)

---

## Setting Values

![h:500 center](img/value_setting_controls.png)

---

## Editing Text

![h:300 center](img/text_editing_controls.png)

---

## Activity Indication

![h:300 center](img/activity_indication_controls.png)

---

## Collections

![h:500 center](img/collection_controls.png)

---

## Pop-ups

![h:300 center](img/popup_controls.png)

---

## Commercial components

![h:350 center invert](img/commercial_components.png)

---

## Bonus - Pages

![h:500 center](img/pages_01.png)

---

## Bonus - Pages

![h:500 center](img/pages_02.png)

---

## Bonus - Pages

- First displayed page is in App.xaml.cs
    - Default - MainPage

---

## Today's Goals

- People introduction
- Get in touch with .NET MAUI
- Go through environment setup
- Get to know available layouts and controls
