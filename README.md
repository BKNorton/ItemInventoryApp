# ItemInventoryApp
Entity Framework API to track an inventory of Items 

Description :
  This app is an API for managing Items in an inventory. It uses Entity Framework to create a database in a local file created 
  by Visual Studios. This is specifically designed to use with the National Guard for the S6 shop at the armory I work at. 
  Items can be added, deleted, updated, and retrieved from this API. Items will have a list of Checkouts to keep track of where 
  and when an item was checked out of the inventory. This checkout history can be retrieved from this API. 

Features :
  1. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program.
     - Lists are used throughout this project. An example can be found in the Item class where it uses a list of type Checkout.
      This list can be populated by creating Checkouts and this list can also be retrieved through this API.

  2. Make a generic class and use it.
     - A generic repository was created and used with the API Controllers.
    
  3. Make your application a CRUD API.
     - This porject is an ASP.net API that uses CRUD methods to create, read, update, and delete items.
    
  4. Make your application asynchronous.
     - The API utilizes asymcronous programming in the Controllers and Repositories.
    
Instructions :
    - No data is seeded to the inventory. Follow these instructions to create an Inventory to work with.
  1. Run the App in Debug mode and wait for the swagger page to open
  2. Click on Post Radio for Items
    - add the following items.
      
          {
            "name": "Radio",
            "serialNumber": 1234,
            "inInventory": true,
            "hasBattery": false
          },
  
          {
            "name": "Radio",
            "serialNumber": 3395,
            "inInventory": true,
            "hasBattery": false
          },
  
          {
            "name": "Radio",
            "serialNumber": 4545,
            "inInventory": true,
            "hasBattery": false
          }         
          
   3. Click on Post Antenna for Items 
     - add the following items

          {
            "name": "Antenna",
            "serialNumber": 9999,
            "inInventory": true,
            "hasAllParts": true,
            "type": "OE-254"
          }

          {
            "name": "Antenna",
            "serialNumber": 9910,
            "inInventory": true,
            "hasAllParts": true,
            "type": "OE-254"
          }

   4. Click on Get for Items
   5. Copy the Items Id from any Item
   6. Click on Post for Checkout
        
          {
            "itemId": {item id you just copied},
            "dateCheckedout": this will populate itself for now,
            "dateReturned": this will populate itself for now,
            "checkedoutTo": "Hill"
          }
  
          {
            "itemId": {Item id you just copied},
            "dateCheckedout": this will populate itself for now,
            "dateReturned": this will populate itself for now,
            "checkedoutTo": "ALOC"
          }

  7. Click on GetItemHistory for Items
     - Use the same Item id you used to create the previous Checkouts and execute to see Items Checkouts
