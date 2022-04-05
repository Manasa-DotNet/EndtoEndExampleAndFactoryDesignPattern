# EndtoEndExampleAndFactoryDesignPattern


Employee Project:

     - It Contains Employee Listing/Create/Edit/Delete.
     - For Simplicity I have not included DB . All Data is written into JSON file in memory.
     - To show case calling external endpoint . I have consumed an endpoint from Github and displayed in it the grid.

Factory Design Pattern:

     - I have chosen a scenario of logging . Based on the type (Generally defined in any configuration) we written log in different source like file, console or DB

     - I have added few Xunit tests to check LoggerFactory is working as expected.
