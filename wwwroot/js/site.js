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

    const button = document.createElement('button');

    data.forEach(d => {
        let isCompleteCheckbox = document.createElement('input'); 

        isCompleteCheckbox.type = 'checkbox';
        isCompleteCheckbox.Disabled = true;
        isCompleteCheckbox.checked = d.IsCompleted;

    })

}

