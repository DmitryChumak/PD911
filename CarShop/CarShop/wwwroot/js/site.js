
$('#car-list')
    .load(`/Home/CarsList`)

$('#search').on('click', function () {

    const searchText = $('#searchText').val()

    $('#car-list')
        .load(`/Home/CarsList/?search=${searchText}`)




    fetch('/Home/CarsJson')
        .then(response => response.json())
        .then(json => console.log(json))

})