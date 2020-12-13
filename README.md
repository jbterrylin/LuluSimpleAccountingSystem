# LuluSimpleAccountingSystem

This is simple accounting system (Can call it accounting? im not sure also hahaha).
Main function done in 1 day. But keep 加花 hahahah
Easy to input. Out data and processed data in csv.

What it do:
  - Input:
    - data(date,component,person,quanity).
    - price for each component X person.
  - Output:
    - Day based data. 
      - 1 day 1 page. 
      - Inside is group by component, 
      - under component is person and quantity, 
      - under quantity have sum of that row.
    - Component based data. 
      - 1 page for all day.
      - Inside is group by component, 
      - under component is person and quantity.
    - Person based data.
      - 2 level column,
        - 1st layer person.
        - 2nd layer sum of quantity, count of quantity.
      - row is component.
    - Paid based data.
      - same as person based data, but
        - there is a price list(column=person, row=component) above person based data
        - there is a row under row of component that contain the total price count from (quantity * price)
    - Component Week Data
      - 2d data(date and component)
      - It will show each total components in that date
        
Interesting place:
  - fast hand focus
    - actually juz 4 type data need to input, but actually first 3 less to change compare with quantity, so on:
      - 1,2,3 press enter will go to next input box
      - 4 press enter will submit data
      - 4 press Q will go to 1st (date) input box, 
        press W will go to 2st (component) input box,
        press E will go to 3st (person) input box
  - delegate 委托 (new learn shit)
    - in price list page, press save btn will call main page function to call price list page to get price list page
    - erm... in simple way
    - A call B to use A function to get A data and save it to B
  - csvhelper
    - c# framework, easy to create csv string to save
  - save and load on half way

Future Enhancement for 1st version:
  - [x] when press save btn on price list page will save （alr have） and auto close it (havent)
  - [x] load data function
  - [x] let price list more easy to input (such as create something to auto fill empty cell with user input data)
  - [x] save half way data to prevent hand ithchy close situation.
  - [x] Simplify the loop function (lazy to do alr hahaha)
  - [x] Find out more magic in csvhelper

Future Enhancement for 2st version:
  - [x] save should be delete and save (do same name file checking in that file to subsitute this shit)
  - [x] let processor become singleton
  - [] find out the way to write generic list
  - [x] find out more thing to 加花 (i think no more can 加花 alr because im lazy as fuck)
  - [x] add comment to hardcore function
  
Enchancement base on user require:
  - [x] add no beside input table
	- [x] add n of pack in list tree
	- [x] input table show most bottom(newest data)
	- [x] add pagination for input table
