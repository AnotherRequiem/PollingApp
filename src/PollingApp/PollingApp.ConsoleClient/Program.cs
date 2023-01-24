using PollingApp.ConsoleClient;

var builder = new PollBuilder("How are u?");
//    .AddAnswer("", "Fine")
//    .AddAnswer("", "Not bad")
//    .AddAnswer("", "Awesome")
//    .AddAnswer("", "Not good at all");

var poll = builder.Build();

//poll.VoteTo(3);
//poll.VoteTo(3);
//poll.VoteTo(2);
//poll.VoteTo(1);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4);
//poll.VoteTo(4, 10);


var result = builder.GetResults(poll);

Console.WriteLine(result.GetView());
