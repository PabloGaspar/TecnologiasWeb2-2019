
//https://www.freecodecamp.org/news/a-practical-es6-guide-on-how-to-perform-http-requests-using-the-fetch-api-594c3d91a547/
//document.querySelector("input[type=button]").addEventListener("click", fetchData);
document.getElementById("fetchbtn").addEventListener("click", fetchData);
document.getElementById("postbtn").addEventListener("click", postData);
document.getElementById("myForm").addEventListener("submit", postData);

function fetchData(){
    fetch('http://localhost:57891/api/values')
    .then((res) => {
        console.log('res:', res);
        return res.json()})
    .catch(error => console.error('Error:', error))
    .then((json) => {
        console.log('Success:', json)
        
        document.querySelector('body .container').innerHTML = '<ul>' + json.map(function (element) {
            return '<li>' + element + '</li>';
        }).join('') + '</ul>'
    });
}

async function fetchDataAsync(){
    try {
        const response = await fetch('http://localhost:57891/api/values');
        const json = await response.json();
        document.querySelector('body .container').innerHTML = '<ul>' + json.map(function (element) {
            return '<li>' + element + '</li>';
        }).join('') + '</ul>'
    } catch (error) {
        console.log(error);
    }
    
    
}

function postData (event){
    console.log('event target', event.target.elements.name.value);
    event.preventDefault();
    /*var url = 'http://localhost:57891/api/values';
    //var data = {username: 'example'};
    var data = 'example';
    fetch(url, {
    method: 'POST', // or 'PUT'
    body: JSON.stringify(data), // data can be `string` or {object}!
    headers:{
        'Content-Type': 'application/json'
    }
    }).then((res) => {
        return res.json()})
    .catch(error => console.error('Error:', error))
    .then((response) => {
        console.log('Success:', response)
    });*/
}

