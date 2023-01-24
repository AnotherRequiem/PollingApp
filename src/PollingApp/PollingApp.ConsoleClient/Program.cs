var builder = new PollBuilder("How are u?")
    .AddAnswer(Guid.Parse("{5DFDD4C6-F6F6-4C62-B087-149C503A8327}"), "Fine")
    .AddAnswer(Guid.Parse("{9BB947FB-4E43-464F-8174-48E460CD2550}"), "Not bad")
    .AddAnswer(Guid.Parse("{CEC24D33-D353-414C-9561-5A643AAD6804}"), "Awesome")
    .AddAnswer(Guid.Parse("{6D3B1A3E-0138-482B-9648-2A3834898BDC}"), "Not good at all");

var poll = builder.Build();

poll.VoteTo(Guid.Parse("{CEC24D33-D353-414C-9561-5A643AAD6804}"));
poll.VoteTo(Guid.Parse("{CEC24D33-D353-414C-9561-5A643AAD6804}"));
poll.VoteTo(Guid.Parse("{9BB947FB-4E43-464F-8174-48E460CD2550}"));
poll.VoteTo(Guid.Parse("{5DFDD4C6-F6F6-4C62-B087-149C503A8327}"), 2);
poll.VoteTo(Guid.Parse("{6D3B1A3E-0138-482B-9648-2A3834898BDC}"));
poll.VoteTo(Guid.Parse("{6D3B1A3E-0138-482B-9648-2A3834898BDC}"));
poll.VoteTo(Guid.Parse("{6D3B1A3E-0138-482B-9648-2A3834898BDC}"));
poll.VoteTo(Guid.Parse("{6D3B1A3E-0138-482B-9648-2A3834898BDC}"));
poll.VoteTo(Guid.Parse("{6D3B1A3E-0138-482B-9648-2A3834898BDC}"));
poll.VoteTo(Guid.Parse("{6D3B1A3E-0138-482B-9648-2A3834898BDC}"));

var result = builder.GetResults(poll);

Console.WriteLine(result.GetView());
