const uri = '/api/shop/';
const uriProducts = '/api/product/';
var currId;

function getItemsDetails(id) {
    currId = id;
    fetch(uri+id)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function deleteItem(id) {
    fetch(uriProducts + id, {
        method: 'DELETE'
    })
        .then(() => getItemsDetails(currId))
        .catch(error => console.error('Unable to delete item.', error));
}

function editItem(id) {
    window.location.href = `/Home/Edit/${id}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('shops');
    let sName = document.getElementById('ShopName');
    let sAdress = document.getElementById('ShopAdress');
    let sTime = document.getElementById('ShopTime');
    tBody.innerHTML = '';

    sName.innerHTML = data.name;
    sAdress.innerHTML = data.adress;
    sTime.innerHTML = data.workHours;

    const button = document.createElement('button');

    data.products.forEach(item => {
        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let updateButton = button.cloneNode(false);
        updateButton.innerText = 'Edit';
        updateButton.setAttribute('onclick', `editItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(item.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode1 = document.createTextNode(item.description);
        td2.appendChild(textNode1);

        let td3 = tr.insertCell(2);
        td3.classList.add("d-flex");
        deleteButton.classList.add("btn", "btn-dark");
        updateButton.classList.add("btn", "btn-dark", "ml-1");
        td3.appendChild(deleteButton);
        td3.appendChild(updateButton);
    });
}
