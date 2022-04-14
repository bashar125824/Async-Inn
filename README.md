# Async-Inn
---
## Name : Bashar Alrefae
---
## Date : 14 / 4 / 2022
---
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

