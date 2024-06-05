//A function/call that creates a "pause" for a certain amount of milliseconds.
//NOTE: 100 milliseconds is equal to 1 second.
setTimeout(function() {
    // Code to be executed after X milliseconds
    
}, 500);


/*This is a way to take an array of objects or whatever and iterate over each item in the array.
One big thing to note here is that the exact same code will be executed against all elements in the array.
*/
Array.from(/*Array Name*/).forEach(element => {
    //Code to execute against each "element"/"item" in the array.
});


/* This is a way to take a string and capitalize the first letter of it. */
// Reference: https://stackoverflow.com/questions/1026069/how-do-i-make-the-first-letter-of-a-string-uppercase-in-javascript
function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}


//Comment section for naming
/********************************************************
 *                  Name
 ********************************************************/