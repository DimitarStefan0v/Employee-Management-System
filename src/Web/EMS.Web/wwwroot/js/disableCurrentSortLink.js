window.onload = disableLink;

function disableLink() {
    const orderValue = document.getElementById('sort-order-value').value;
    const [asc, desc, pendingTasks, finishedTasks, salary] = [...document.querySelectorAll('.sort-wrapper ul li a')];

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
        'pending-tasks': function () {
            pendingTasks.style.color = 'red';
            pendingTasks.style.borderBottom = '5px solid red';
            pendingTasks.style.pointerEvents = 'none';
            pendingTasks.style.cursor = 'default';
        },
        'finished-tasks': function () {
            finishedTasks.style.color = 'red';
            finishedTasks.style.borderBottom = '5px solid red';
            finishedTasks.style.pointerEvents = 'none';
            finishedTasks.style.cursor = 'default';
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