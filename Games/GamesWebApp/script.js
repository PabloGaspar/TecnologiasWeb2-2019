document.getElementById("getGamesBtn").addEventListener("click", 
async function(){
    try {
        const request = await fetch('http://localhost:1936/api/games');
        //console.log(request);
        const data = await request.json()
        //console.log(data); 
        document.getElementById("gamesContainer").innerHTML = 
        `<ul>  ${data.map(e => `<li> ${e.name} | ${e.genre} | ${e.price} $</li>`).join('')} </ul>`

    } catch (error) {
        
    }
    
    /*.then( function (response){
        console.log('response:',response); 
        return response.json()
        }) //response => {return response.json()})
     .then(data => console.log('data:',data))
     .catch(function(){})
     .finally*/
});

document.getElementById("newGameFrm").addEventListener("submit", PostGame)

function PostGame(event){
    event.preventDefault();
    const formElements = event.target.elements;
    console.log('gasda',formElements.newGameName.value);

    var url = 'http://localhost:1936/api/games';
    var data = {
        name: formElements.newGameName.value,
        price: formElements.newGamePrice.value,
        genre: formElements.newGameGenre.value
    };
   
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
    });
}