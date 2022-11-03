// function handleOnLoad(){
//     createCategoryTable();
// }


// let drivers = [];

// function handleOnLoad(){
//     createDriverTable();
//     postDriver();

// }
 


// function createDriverTable(){
//     let table = document.createElement('TABLE');
//     table.id = 'driverTable';
//     table.border = '1';
//     table.className = 'table table-striped"'
//     let tableBody = document.createElement('TBODY');
//     tableBody.id = 'driverTableBody';
//     table.appendChild(tableBody);

//     //create header row
//     let tr = document.createElement('TR');
//     tableBody.appendChild(tr);

//     // let th1 = document.createElement('TH');
//     // th1.width = 150;
//     // th1.appendChild(document.createTextNode('ID'));
//     // tr.appendChild(th1);

//     let th2 = document.createElement('TH');
//     th2.width = 300;
//     th2.appendChild(document.createTextNode('Name'));
//     tr.appendChild(th2);

//     let th3 = document.createElement('TH');
//     th3.width = 150;
//     th3.appendChild(document.createTextNode('Rating'));
//     tr.appendChild(th3);

//     let th4 = document.createElement('TH');
//     th4.width = 150;
//     th4.appendChild(document.createTextNode('Date Hired'));
//     tr.appendChild(th4);
//     console.log("made it here");
//     return table;
    
// }


function getDrivers(){
    const allDriversApiUrl = "https://localhost:7115/api/drivers";
    document.getElementById("drivers").innerHTML="";
    fetch(allDriversApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let ul = document.createElement("ul");
        json.forEach((driver)=>{
            let dateHired = new Date(driver.dateHired);
            let li = document.createElement("li");

            let rating = document.createElement("select");
            for(let i = 0; i<6; i++){
                rating.innerHTML+=`<option>${i}</option>`;
            }
            rating.value=driver.rating;

            li.innerHTML= `Driver Name: ${driver.name} <br />
            Date Hired: ${dateHired.toLocaleDateString('en-US')} <br />
            
            `;
            li.appendChild(rating);

            let deleteBtn = document.createElement("button"); //created delete button
            deleteBtn.innerHTML = "Fire Driver";

            //onclick what it does pass driver id
            deleteBtn.onclick = function () { 
                deleteDriver(driver.id);
                li.remove();
              };

              //added onto list items
            li.appendChild(deleteBtn);
            ul.appendChild(li);

            let editBtn = document.createElement("button"); //created edit button
            editBtn.innerHTML = "Edit Rating";
            

            editBtn.onclick = function () {
                // let id = document.getElementById('id').value;
                // let rating = document.getElementById('rating').value;

                editDriver(driver.id, rating.value);
              
            };

            li.appendChild(editBtn);
            ul.appendChild(li);
     
        });
       
        document.getElementById("drivers").appendChild(ul);
        console.log(json);
    }).catch(function(error){
        console.log(error);
    });
}

function postDriver(){
    
    const postDriversApiUrl = "https://localhost:7115/api/drivers";
    const driverName = document.getElementById("driver_name").value;
    const rating = document.getElementById("rating").value;
    const dateHired = document.getElementById("date_hired").value;
  

    fetch(postDriversApiUrl, {
        // mode: 'cors',
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            name: driverName,
            rating: rating,
            dateHired: dateHired

        })
    })
    .then((response)=> {
        console.log(response);
        getDrivers();
    })
}

function deleteDriver(id){
    const deleteDriversApiUrl = "https://localhost:7115/api/drivers/" + id;
    

    fetch(deleteDriversApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        }
    
    })
    .then((response)=> {
        console.log(response);
        // getDrivers();
    })

}

function editDriver(id, rating){
    const editDriversApiUrl = "https://localhost:7115/api/drivers/" + id;
    // const id = document.getElementById("id").value;
    // const rating = document.getElementById("rating").value;

    fetch(editDriversApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },

        body: JSON.stringify({
            rating: rating,
            id: id
        })

        
    })
    .then((response)=> {
        console.log(response);

    })
}



    

