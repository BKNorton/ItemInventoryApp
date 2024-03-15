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
  1. Update the migrations.
  2. Run the App in Debug mode and wait for the swagger page to open.
  3. Click on Post Radio.
  4. Click on Try it out.

![Screenshot (29)](https://github.com/BKNorton/ItemInventoryApp/assets/112774855/f11762da-4f13-4d29-8434-2e8d4aca1c32)

  5. Add the following items, one at a time.
     - We're not adding Id because one is made autimatically for us.
     - Click Execute to add.

  ![Screenshot (30)](https://github.com/BKNorton/ItemInventoryApp/assets/112774855/a5b229e5-e8b4-48f8-be37-e417584eb320)


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
          
   7. Click on Post Antenna for Items. 
   8. Add the following items.

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

![Screenshot (28)](https://github.com/BKNorton/ItemInventoryApp/assets/112774855/859f1056-8792-4ad7-be14-4b6a94bc048b)

   1. Click on Get for Items.
   2. View Items by Id.
      - Click Get Items{id} and use an Items Id to retrieve it.

### How to add a Checkout to an Item and look up an Items Checkout History
   1. Click on Post for Checkout.
        
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

  2. Click on GetItemHistory for Items.
     - Use the same Item Id you used to create the previous Checkouts and execute to see Items Checkouts.
    
# Updates
  I am currently in the process of shifting this project into a .net maui project. I plan to either connect the .net maui 
  app to this api or (most likely) will recreate this database using Azure. Check back soon for more updates.
