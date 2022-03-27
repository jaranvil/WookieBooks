# WookieBooks
This is a demostration project I coded on March 27th, 2022. It is an implementation of a RESTful .NET Core API for a bookstore. It uses a EF Core In-Mmemory repository with two default book records.

## Deployment

The API is hosted as a Azure App Service here:
https://wookiebooks20220327145308.azurewebsites.net

## Postman Test

A collection of Postman tests are located in /PostmantTest/WookieBooks.postman_collection.json

## API Calls

### Read All
Reads all book records with paging.

**URL** /books/all

**Method** GET

**Parameters**
- **page** - Page number to load  
- **count** - Number of records per page

**Sample**

Request
~~~
GET https://wookiebooks20220327145308.azurewebsites.net/books/all?page=1&count=10
~~~
Resposne Body
~~~
[
  {
    "id": 1,
    "title": "What's Weirder Than A Wookiee?",
    "description": "Meet some friendly (and not so friendly) creatures from across the Star Wars galaxy. Read about what they look like, where they live and who their friends are.",
    "author": "Laura Buller",
    "coverImage": "~/images/book1.png",
    "price": 9.99
  },
  {
    "id": 2,
    "title": "A Forest Apart",
    "description": "Lumpawarrump finds a burglar at Han and Leia Solo's apartment and pursues him into Coruscant's dangerous under-levels. Chewbacca and his wife, Mallatobuck, follow their son to find him fighting the burglar in the company of a band of thieves.",
    "author": "Troy Denning",
    "coverImage": "~/images/book2.png",
    "price": 14.99
  }
]
~~~

### Read
Read a single book record by ID.

**URL** /books/read

**Method** GET

**Parameters**
- **id** - ID of book to load

**Sample**

Request
~~~
GET https://wookiebooks20220327145308.azurewebsites.net/books/read?id=1
~~~
Resposne Body
~~~
{
  "id": 1,
  "title": "What's Weirder Than A Wookiee?",
  "description": "Meet some friendly (and not so friendly) creatures from across the Star Wars galaxy. Read about what they look like, where they live and who their friends are.",
  "author": "Laura Buller",
  "coverImage": "~/images/book1.png",
  "price": 9.99
}
~~~

### Create
Create a new book record.

**URL** /books/create

**Method** POST

**Sample**

Request
~~~
POST https://wookiebooks20220327145308.azurewebsites.net/books/create
~~~
Request Body
~~~
{
  "title": "Test Title",
  "description": "Test Description",
  "author": "Test Author",
  "coverImage": "image.png",
  "price": 1
}
~~~
Resposne Body
~~~
{
  "id": 3,
  "title": "Test Title",
  "description": "Test Description",
  "author": "Test Author",
  "coverImage": "image.png",
  "price": 1
}
~~~

### Update
Update an existing book record

**URL** /books/update

**Method** PUT

**Sample**

Request
~~~
PUT https://wookiebooks20220327145308.azurewebsites.net/books/update
~~~
Request Body
~~~
{
  "id": 1,
  "title": "New Title"
}
~~~
Resposne Body
~~~

  "id": 1,
  "title": "New Title",
  "description": "Meet some friendly (and not so friendly) creatures from across the Star Wars galaxy. Read about what they look like, where they live and who their friends are.",
  "author": "Laura Buller",
  "coverImage": "~/images/book1.png",
  "price": 9.99
}
~~~

### Delete
Delete an existing book record

**URL** /books/delete

**Method** DELETE

**Sample**

Request
~~~
DELETE https://wookiebooks20220327145308.azurewebsites.net/books/delete
~~~
Request Body
~~~
{
  "id": 1
}
~~~
Resposne Body
~~~

~~~




