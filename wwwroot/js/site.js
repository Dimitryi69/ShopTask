const uri = 'api/shop';
function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}


function _displayItems(data) {
    const tBody = document.getElementById('shops');
    tBody.innerHTML = '';
    data.forEach(item => {
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(item.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode1 = document.createTextNode(item.adress);
        td2.appendChild(textNode1);

        let td3 = tr.insertCell(2);
        let textNode2 = document.createTextNode(item.workHours);
        td3.appendChild(textNode2);

        let td4 = tr.insertCell(3);
        let link = document.createElement("a");
        link.href = "Home/Details/" + item.id;
        let textNode3 = document.createTextNode("Details");
        link.appendChild(textNode3);
        td4.appendChild(link);
    });
}
