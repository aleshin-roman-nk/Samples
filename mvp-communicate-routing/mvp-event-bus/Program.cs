using mvp_event_bus;

EventBus eventBus = new EventBus();

DataService dataService = new DataService();
Controller controller = new Controller(dataService, eventBus);
View view = new View(eventBus);

view.RequestData();


Console.ReadLine();