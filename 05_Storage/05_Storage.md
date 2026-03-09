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

# PV239 – 05 Storage

---

## Project status

- Teams
- Topic submission
- Discord
- Consultations

---

## Goals

- Storing values
- Storing values securely
- Storing data locally
- Sending messages between different application parts

---
## Preferences
<!--
header: '**Preferences** &nbsp;&nbsp; Secure Storage &nbsp;&nbsp; Database &nbsp;&nbsp; Converters'
-->

- For storing small amounts of values
- Limit for size of individual records
- Synchronous API
- Supported types:
    - bool
    - int, long
    - float, double
    - string
    - DateTime

---

## Preferences

- Android
    - Stored in Shared Preferences
    - Enables automatic backup to Google Drive – from Android 6.0 (API level 23)

- iOS
    - Stored in NSUserDefaults
    - Backup in iCloud

---

## Preferences
<!-- _class: demo -->

# DEMO

---

## Secure Storage
<!--
header: 'Preferences &nbsp;&nbsp; **Secure Storage** &nbsp;&nbsp; Database &nbsp;&nbsp; Converters'
-->

- Useful for storing small amounts of data securely (i.e. authentication token)
- Supports only strings
- Asynchronous API

---

## Secure Storage
- Android
    - Stored in Shared Preferences
    - Encrypted using a key from Android KeyStore

- iOS
    - Stored in KeyChain
    - Backup is on/off based on user’s settings

---

## Secure Storage
<!-- _class: demo -->

# DEMO

---

## SQLite
<!--
header: 'Preferences &nbsp;&nbsp; Secure Storage &nbsp;&nbsp; **Database** &nbsp;&nbsp; Converters'
-->

- Nuget package sqlite-net-pcl from author „Frank A. Krueger“
- We need to set a path to the database file
- Basic ORM
- Basic operations

| | |
|--|--|
| Table<T> | Query<T> |
| Insert | Execute |
| Update | ExecuteScalar |
| Delete | CreateTable |

---

## Mapping

- Nuget package **Mapperly**

---

## Database
<!-- _class: demo -->

# DEMO

---

## Which storage option would you use?
- Options: Preferences, Secure Storage, Database
- Examples:
    - Authentication
    - Selecting color schema
    - Saving a recipe
    - Saving settings about how items are ordered in a list (alphabetically, by date created...)

---

## Converters
<!--
header: 'Preferences &nbsp;&nbsp; Secure Storage &nbsp;&nbsp; Database &nbsp;&nbsp; **Converters**'
-->

- Convert value of 1 type to another type
- Interface **IValueConverter**
- CommunityToolkit.Mvvm - **BaseConverterOneWay**
- **IMultiValueConverter**

---

## Converters
<!-- _class: demo -->

# DEMO