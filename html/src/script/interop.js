const cs_initialize = function(arg) {
    // Reads page title
    const title = document.getElementsByTagName("title")[0].text;

    // Passes it to interop to change title of window
    // interop functions can have many amount of args,
    // but the C# function receives a string in the form ["a","b","c",...]
    cs_extern_initialize(title);
}


const cs_navigate = function (arg) {

    // cs_extern_navigate() is defined in Program.cs by using .Bind()
    cs_extern_navigate(arg);
}
