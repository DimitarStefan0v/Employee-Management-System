window.onload = disableLink;

function disableLink() {
    const orderValue = document.getElementById('sort-order-value').value;
    const [startDate, dueDate, title] = [...document.querySelectorAll('.sort-wrapper ul li a')];

    const obj = {
        'startDate': function () {
            startDate.style.color = 'red';
            startDate.style.borderBottom = '5px solid red';
            startDate.style.pointerEvents = 'none';
            startDate.style.cursor = 'default';
        },
        'dueDate': function () {
            dueDate.style.color = 'red';
            dueDate.style.borderBottom = '5px solid red';
            dueDate.style.pointerEvents = 'none';
            dueDate.style.cursor = 'default';
        },
        'title': function () {
            title.style.color = 'red';
            title.style.borderBottom = '5px solid red';
            title.style.pointerEvents = 'none';
            title.style.cursor = 'default';
        },
    };

    const result = obj[orderValue];
    result();
}