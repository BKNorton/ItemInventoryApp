<h1>
  Description
</h1>
<p>
  This is an ASP .Net web API used to manage the inventory for the armory I work at. It uses entity framework to implement the SQLite database.
</p>
<h2>
  Notes
</h2>
<ul>
  <li>This creates the database for you. There is no existing database and all tables will need to be populated by each individual user (currently)</li>
</ul>

    
# Instructions 

  ### No data is seeded to the inventory. Follow these instructions to create an Inventory to work with.
  1. Update the migrations
  2. Run the App in Debug mode and wait for the swagger page to open
  3. Click on Post Radio for Items
    - add the following items, one at a time.
      
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

     ![Screenshot (27)](https://github.com/BKNorton/ItemInventoryApp/assets/112774855/d9522bbc-469d-4629-b519-78cd84781659)
          
   5. Click on Post Antenna for Items 
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

### How to view Items 
   1. Click on Get for Items
   2. Copy the Items Id from any Item

### How to add a Checkout to an Item and look up an Items Checkout History
   1. Click on Post for Checkout
        
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

  2. Click on GetItemHistory for Items
     - Use the same Item id you used to create the previous Checkouts and execute to see Items Checkouts
    
# Updates
  I am currently in the process of shifting this project into a .net maui project. I plan to either connect the .net maui 
  app to this api or (most likely) will recreate this database using Azure. Check back soon for more updates.
