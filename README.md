# LuluSimpleAccountingSystem

thing to do:
    save should be delete and save
    let processor become singleton

This is simple accounting system (Can call it accounting? im not sure also hahaha).
Do in 1 day.
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

Future enhancement when 1st version:
  - when press save btn on price list page will save （alr have） and auto close it (havent)
  - load data function
  - let price list more easy to input (such as create something to auto fill empty cell with user input data)
  - save half way data to prevent hand ithchy close situation.
  - Simplify the loop function
  - Find out more magic in csvhelper
