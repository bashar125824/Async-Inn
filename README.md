# Async-Inn
---
## Name : Bashar Alrefae
---
## Date : 28 / 4 / 2022
---

# Lab 16 :

***Cleaning up inputs and outputs of controllers to DTO's***

---

## Room Routings :

- **GET: api/Rooms** :	***return all rooms***
- **GET: api/Rooms/{id}**	: ***return room with id provided***
- **PUT: api/Rooms/{id}**	: ***update room with id provided***
- **POST: api/Rooms** : 	***add a new room***
- **POST: api/Rooms/{roomId}/Amenity/{amenityId}**	: ***add aminity to room , depending on it's Id***
- **DELETE: api/Rooms/{id}** :	***delete room with id provided***
- **DELETE: api/Rooms/{roomId}/Amenity/{amenityId}** :	***delete aminity to room , depending on it's Id***

---

## Hotel Routings :

- **GET: api/Hotels** :	***return all hotels***
- **GET: api/Hotels/{id}** : ***return hotel with id provided***
- **PUT: api/Hotels/{id}** : ***update hotel with id provided***
- **POST: api/Hotels** : ***add new hotel***
- **DELETE: api/Hotels/{id}** :	***delete hotel with id provided***

---

## Amenity Routings :

- **GET: api/Amenities** :	***return all amenities***
- **GET: api/Amenities/{id}** : ***return amenity with id provided***
- **PUT: api/Amenities/{id}** : ***update amenity with id provided***
- **POST: api/Amenities** : ***add new amenity***
- **DELETE: api/v/{id}** :	***delete amenity with id provided***

---

## Architecture :

***In this lab , we just divide the work of controller , between interfaces and services , (interfaces and services are layers between controller and database) , so we used refactoring to apply the Dependency Injection***

## Postman Verification : 

***I use Rooms Table :***

- **GET**

![IMG](/Get.PNG)

---

- **POST**

![IMG](/Post2.PNG)

---

- **DELETE**

![IMG](/delete.PNG)

## Hotel ERD  :

![IMG](/Diagram2.PNG)

---
## Explanation : 

- **Hotel Table** : *have **hotel-Id**(int) as a primary key , and it has name(varchar), city(varchar), state(varchar), address(varchar), and phone number(varchar) as attributes . Relationship is (one-to-many) with the join table Hotle_Room .*

- **Hotel_Room Table** : *have **hotle_room_id**(int) as primary key , price(double), pet_fiendly(bool), room_num(int) as attributes , hotle_id , room _id as foreign keys.*

- **Room Table** : *have **room _id**(int) as primary key and have nickname(varchar) and layout(varchar) as attributes. Relationship is (one to many) with join table hotel_room and (one to many) with Room_Amenity table.*

- **Aminity Table**: *have **amenitiy _id**(int) as primary key and name(varchar) as attribute , Relationship (one to many) with room amenity table*

- **Room_Amenity Table** : *have **room_aminity_id**(int) as primary key , room_id and aminity_id as foreign keys*

**Room Layout Table**: *have **layout_id**(int) as primary key , bedroom_number(int) and style(varchar) as attributes ,  Relationship is (one to many) with Room table.*

