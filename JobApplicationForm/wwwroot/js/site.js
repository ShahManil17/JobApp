let delIds = '';

function add() {
    let copyDiv = document.getElementById("copy");
    let cloneNode = copyDiv.cloneNode(true);
    let ele = document.getElementById("expContent").appendChild(cloneNode);
    ele.style.visibility = 'visible';
    console.log(ele.children);
    Array.from(ele.children).forEach(function (element, index) {
        switch (index) {
            case 0:
                element.children[2].name = 'Company'
                break;
            case 1:
                element.children[2].name = 'Designation'
                break;
            case 2:
                element.children[2].name = 'From'
                break;
            case 3:
                element.children[2].name = 'To'
                break;
        }
        element.children[2].value = ""
    })
}

function storeId(id) {
    document.getElementById(`row+${id}`).style.display = 'none';
    delIds += `${id},`;
}

function change(id) {
    if (document.getElementById(id).checked == true) {
        document.getElementById(id + "Read").disabled = false;
        document.getElementById(id + "Write").disabled = false;
        document.getElementById(id + "Speak").disabled = false;
    }
    else {
        document.getElementById(id + "Read").checked = false;
        document.getElementById(id + "Read").disabled = true;

        document.getElementById(id + "Write").checked = false;
        document.getElementById(id + "Write").disabled = true;

        document.getElementById(id + "Speak").checked = false;
        document.getElementById(id + "Speak").disabled = true;
    }
}

function techChange(id) {
    if (document.getElementById(id).checked == true) {
        document.getElementById(id + "Begginer").disabled = false;
        document.getElementById(id + "Mediator").disabled = false;
        document.getElementById(id + "Expert").disabled = false;
    }
    else {
        document.getElementById(id + "Begginer").checked = false;
        document.getElementById(id + "Begginer").disabled = true;

        document.getElementById(id + "Mediator").checked = false;
        document.getElementById(id + "Mediator").disabled = true;

        document.getElementById(id + "Expert").checked = false;
        document.getElementById(id + "Expert").disabled = true;
    }
}

function validate() {
    const expEle = document.getElementById("expContent").children;
    for (let i = 0; i < expEle.length; i++) {
        for (let j = 0; i < 4; j++) {
            if (expEle[i].children[j].children[3]) {
                expEle[i].children[j].children[3].style.display = 'none';
            }
            
            if (expEle[i].children[j].children[2].value.trim() == '' && expEle[i].style.visibility == 'visible') {
                document.getElementById("3").style.display = 'block';
                document.getElementById("5").style.display = 'none'
                expEle[i].children[j].children[2].focus();
                const node = document.createElement("span");
                const text = document.createTextNode("This Field is mendatory");
                node.appendChild(text);
                node.style.color = 'red';
                expEle[i].children[j].appendChild(node);
                return false;
            }
        }
    }
    return true;
}

function prev(id) {
    document.getElementById(id).style.display = 'none';
    document.getElementById(Number(id) - 1).style.display = 'block'
}

function next(id) {
    if (id == 3 && delIds != '')
    {
        delIds = delIds.slice(0, delIds.length-1);
        document.getElementById("delExp").value = delIds;
        alert(delIds);
    }
    document.getElementById(id).style.display = 'none';
    document.getElementById(Number(id) + 1).style.display = 'block'
}