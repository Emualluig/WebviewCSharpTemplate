
// cs_initialize(arg) pass a single arg to c# function
// effects: changes window title, interops with c#
const cs_initialize = function(arg) {
    // Reads page title
    const title = document.getElementsByTagName("title")[0].text;

    // Passes it to interop to change title of window
    // interop functions can have many amount of args,
    // but the C# function receives a string in the form ["a","b","c",...]
    cs_extern_initialize(title);
}

// cs_navigate(arg) pass a single arg to c# function
// effects: changes current page to the one specified i arg
const cs_navigate = function (arg) {

    // cs_extern_navigate() is defined in Program.cs by using .Bind()
    cs_extern_navigate(arg);
}

cs_initialize();