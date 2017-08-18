# Hair Salon Stylist and Client Tracker

#### C# Database Basics Project, 8/18/2017

#### By _Ben Budinger_

## Description

_This site uses a SQL database to track a hair salon's stylists and their associated clients_
* The employee can view a list of all stylists
* The employee can view a stylist's details, as well as their clients
* The employee can add stylists when they are hired
* The employee can add clients to a stylist
* The employee can update client names
* The employee can delete clients when they no longer visit the salon

### Technical Specifications

|Behavior|Expected|Actual|
|-|-|-|
|Home page view|List of all stylists|All stylists from DB|
|Click on a stylist|Stylist details and client list|Stylist details and client list from DB|
|Click Add Stylist button|Add Stylist|Add stylist to DB|
|Click Add Client button|Add client to specific stylist|Add client with stylist_id to DB|
|Click on Client|Update client information|Update client information in DB|
|Click on Delete Client button|Removes client from stylist details page|Deletes client from DB|


## Setup

* This website will be hosted on GitHub
* https://github.com/budingerbc/HairSalon

##### Database Creation/Setup - Commands
1. CREATE DATABASE hair_salon;
2. USE hair_salon;
3. CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR (255));
4. CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR (255), stylist_id int)

* The DB hair_salon_test is used for MST Unit testing

## Technologies Used

* HTML
* CSS
* Bootstrap
* C#
* Razor

### License

* Copyright (c) 2017 Ben Budinger
* This software is licensed under the MIT license.
