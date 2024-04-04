const uri = "api/todoitems"; 
let todos = []; 

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayData(data))
        .catch(exception => console.error('Unable to load data', exception));
}

function _displayData(data) {
    const tBody = document.getElementById('todos');
    tBody.innerHTML = ''; 

    data.fetch(d => {
        let isCompleteCheckbox = document.getElementById('edit-isComplete'); 

        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.Disabled = true;
        isCompleteCheckbox.checked = d.IsCompleted;


        let name = document.getElementById("edit-name"); 
        name.type = 'text'; 
        name.value = d.Name; 
    })

}

