
/* Functions */
function log(message) {
    console.log();
    console.log(`[${ new Date().toLocaleDateString() } - ${ new Date().toLocaleTimeString() }] ${ message }`);
}

function table(table, title) {
    console.log();
    console.log(`[${ new Date().toLocaleDateString() } - ${ new Date().toLocaleTimeString() }] ${ title }`);
    console.table(table);
}

function error(message) {
    console.log();
    console.error(`[${ new Date().toLocaleDateString() } - ${ new Date().toLocaleTimeString() }] ${ message }`);
}

function warning(message) {
    console.log();
    console.warn(`[${ new Date().toLocaleDateString() } - ${ new Date().toLocaleTimeString() }] ${ message }`);
}


function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}