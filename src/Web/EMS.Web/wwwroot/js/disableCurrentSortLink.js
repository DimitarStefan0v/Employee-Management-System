window.onload = disableLink;

function disableLink() {
    const orderValue = document.getElementById('sort-order-value').value;
    const [asc, desc, tasks, salary] = [...document.querySelectorAll('.sort-wrapper ul li a')];

    const obj = {
        'ascending': function () {
            asc.style.color = 'red';
            asc.style.borderBottom = '5px solid red';
            asc.style.pointerEvents = 'none';
            asc.style.cursor = 'default';
        },
        'descending': function () {
            desc.style.color = 'red';
            desc.style.borderBottom = '5px solid red';
            desc.style.pointerEvents = 'none';
            desc.style.cursor = 'default';
        },
        'tasks': function () {
            tasks.style.color = 'red';
            tasks.style.borderBottom = '5px solid red';
            tasks.style.pointerEvents = 'none';
            tasks.style.cursor = 'default';
        },
        'salary': function () {
            salary.style.color = 'red';
            salary.style.borderBottom = '5px solid red';
            salary.style.pointerEvents = 'none';
            salary.style.cursor = 'default';
        },
    };

    const result = obj[orderValue];
    result();
}