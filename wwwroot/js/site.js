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

        //edit button 
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onClick', `displayEditForm(${d.Id})`);

        //delete button 
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onClick', `deleteItem(${d.Id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(isCompleteCheckbox);

        let td2 = tr.insertCell(1);
        let text = document.createTextNode(d.Name);
        td2.appendChild(text);


        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);


        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    todos = data;
}

function addItem() {
    const addNameTextBox = document.getElementById('add-name');

    const item = {
        id: 1,
        isCompleted: false,
        name: addNameTextBox.value
    };


    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
       
        .then(() => {
            getItems();
            addNameTextBox.value = '';
        }
        )
        .catch((error) => console.error("Something wrong", error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch((error) => console.error("Something wrong", error));
}

function displayEditForm(id) {
    const item = todos.find(i => i.Id == id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-isComplete').checked = item.isCompleted;
    document.getElementById('edit-form').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;

    const item = {
        id: parseInt(itemId),
        name: document.getElementById('edit-name').value,
        isCompleted: document.getElementById('edit-isComplete').checked
    }

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch((error) => console.error("Something wrong", error));

    close();
}

function close() {
    document.getElementById('edit-form').style.display = 'none';
}


