$('#save').click(function () {
    //var selectedValue = $("select[name='selectedValue']")[0];
    $.ajax({
        data: {
            "Ime": "Novica fdfd",
            "Prezime": "Velickovic fdf",
            "Visina": "205",
            "Tezina": 110,
            "drzava_id": 1,
            "klubId": 2
        },
        url: 'http://localhost:59466/api/players/3',
        type: "PUT",
        success: function (returndata) {
            console.log(returnData)
        },
        error: function (error) {
            console.log(error)
        }
    });
});