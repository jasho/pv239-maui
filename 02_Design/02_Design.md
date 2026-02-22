---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
marp: true
---

<style>
    @import url('../styles/presentation-styles.css');

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
</style>

# PV239 – 02 Design

---

## Goals

- Get to know available layouts
- Create a layout with some controls
- Get to know available navigation options
- Styles
- Localization

---

## Controls
<!--
header: '**Layouts** &nbsp;&nbsp; Navigation &nbsp;&nbsp; Styles &nbsp;&nbsp; Localization'
-->

<!-- _class: controls-grid -->

| | | | | |
|:--:|:--:|:--:|:--:|:--:|
| ActivityIndicator | BoxView | Button | DatePicker | Editor |
| Entry | Image | Label | TimePicker | Slider |
| OpenGLView | Picker | ProgressBar | SearchBar | Stepper |
| WebView | TableView | ListView | TextCell | EntryCell |
| ImageCell | SwitchCell | ViewCell | Map | ... |

---

## Layouts
<!-- _class: layout-table -->

| **Grid** | **StackLayout** |
|:--------:|:---------------:|
| ![](img/layouts_grid.png) | ![](img/layouts_stack-layout.png) |

---

## Grid

- Table-style layout
- RowDefinitions, ColumnDefinitions
    - Width / Height = 150 | * | Auto
- Grid.Row, Grid.Column – placement of control in the Grid
- Grid.RowSpan, Grid.ColumnSpan – control can span over multiple “cells”
- HorizontalSpacing, VerticalSpacing – empty space between “cells”

---

## Layouts - StackLayout
<!-- _class: layout-table -->

| **VerticalStackLayout** | **HorizontalStackLayout** |
|:------------------:|:--------------:|
| ![](img/layouts_vertical-stack-layout.png) | ![](img/layouts_horizontal-stack-layout.png) |

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
<!-- _class: layout-table -->

| **AbsoluteLayout** | **FlexLayout** |
|:------------------:|:--------------:|
| ![](img/layouts_absolute-layout.png) | ![](img/layouts_flex-layout.png) |

---

## Layouts demo
<!-- _class: demo -->

![h:500 center](img/layouts_demo.png)

---

## Shell

<!--
header: 'Layouts &nbsp;&nbsp; **Navigation** &nbsp;&nbsp; Styles &nbsp;&nbsp; Localization'
-->

- Application layout
- Navigation using URIs
- Hierarchical navigation
- Easy passing of parameters between pages
    - String parameters or strongly typed objects
    - Works even in backwards navigation “..?success=true”

---

## Shell - Flyout
<!-- _class: two-column -->
<style scoped>
section.two-column {
    --col1-width: 80%;
    --col2-width: 20%;
    --col1-align: left;
    --col2-align: right;
    --col1-valign: top;
    --col2-valign: middle;
}
</style>

| | |
|--|--|
| <ul><li>Header</li><li>Items</li><li>Footer</li></ul><ul><li>Support for text, icons or custom templates</li></ul> | ![](img/shell_flyout.png) |

---

## Shell - tabs
<!-- _class: two-column -->
<style scoped>
section.two-column {
    --col1-width: 70%;
    --col2-width: 30%;
    --col1-align: left;
    --col2-align: right;
    --col1-valign: top;
    --col2-valign: middle;
}
</style>

| | |
|--|--|
| <ul><li>2 levels of hierachy<ul><li>Bottom tabs</li><li>Top tabs</li></ul></li></ul><ul><li>Support for text, icons, custom templates</li></ul> | ![](img/shell_tabs.png) |

---

## Shell - MenuBar
<!-- _class: two-column -->
<style scoped>
section.two-column {
    --col1-width: 70%;
    --col2-width: 30%;
    --col1-align: left;
    --col2-align: right;
    --col1-valign: top;
    --col2-valign: top;
}
</style>

| | |
|--|--|
| <ul><li>MenuBarItem</li><li>MenuFlyoutItem</li><li>MenuFlyoutSubItem</li><br/><li>Support for text, icons</li></ul> | ![](img/shell_menu-bar.png) |

---

## NavigationPage

- NavigationPage
- PushAsync
- PopAsync

---

## Pages
<!-- _class: layout-table -->

| **ContentPage** | **TabbedPage** | **FlyoutPage** |
|:------------------:|:--------------:|:--------------:|
| ![](img/pages_content-page.png) | ![](img/pages_tabbed-page.png) | ![](img/pages_flyout-page.png) |

---

## Navigation
<!-- _class: demo -->

# DEMO

---

## Resources
<!--
header: 'Layouts &nbsp;&nbsp; Navigation &nbsp;&nbsp; **Styles** &nbsp;&nbsp; Localization'
-->

- Each element contains a collection of **Resources**
- Resources can define any content
- Referencing using **x:Key**
- Access with **{StaticResource Key}**
- Can be defined in separate files - **merged dictionaries**
- Hierarchical application
    - Can be overridden on any level

---

## Styles
- Setting style for a control
- **TargetType** – specifies which element type it should be applied to
- **x:Key** – key of style, can be omitted – in that case it will be automatically applied to all controls of the type
- Collection of **Setter** objects
    - **Property**
    - **Value**
- **BasedOn** – base style that this style extends – optional

---

## Styles
<!-- _class: demo -->

# DEMO

---

## Localization
<!--
header: 'Layouts &nbsp;&nbsp; Navigation &nbsp;&nbsp; Styles &nbsp;&nbsp; **Localization**'
-->

- .resx files
- Separate files for separate views
- Don’t use resources in multiple places

---

## Localization
<!-- _class: demo -->

# DEMO

---

## Goals

- Get to know available layouts
- Create a layout with some controls
- Get to know available navigation options
- Styles
- Localization