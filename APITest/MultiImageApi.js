
$(function () {

    $('button[id=btnMultiImage]').on('click', function () {

        $.ajax({
            url: "http://localhost:54076/api/MultiImage",
            type: "get",
            datatype: "json"
        }).done(function (data, textStatus, xhr) {
            //XMLの場合
            // $("#imagebox").attr("src", "data:image/jpeg:base64," + $(data).find("Image").eq(0).text());

            const v = $(data)[0];
            for (let i in v.Data) {
                $("#imagebox").append("<img src='data:image/png;base64," + v.Data[i].Image + "' />");
            }

        }).fail(function (xhr, textStatus, errorThrown) {
            alert("NG");
            alert("status:" + xhr.status + "\n" +
                "textStatus:" + textStatus + "\n" +
                "errorThrown:" + errorThrown);
        });
    });

    $('button[id=btnMultiImage2]').on('click', function () {

        $.ajax({
            url: "http://localhost:54076/api/MultiImage",
            type: "get",
            datatype: "xml"
        }).done(function (data, textStatus, xhr) {
            //XMLの場合
            // $("#imagebox").attr("src", "data:image/jpeg:base64," + $(data).find("Image").eq(0).text());

            const v = $(data)[0];
            // for (let i in v.Data) {
            //     $("#imagebox2").append("<img src='data:image/png;base64," + v.Data[i].Image + "' />");
            // }

        }).fail(function (xhr, textStatus, errorThrown) {
            alert("NG");
            alert("status:" + xhr.status + "\n" +
                "textStatus:" + textStatus + "\n" +
                "errorThrown:" + errorThrown);
        });
    });

    $('button[id=btnMultiImage3]').on('click', function () {

        $.ajax({
            url: "http://localhost:54076/api/MultiImage",
            type: "get",
            datatype: "json"
        }).done(function (data, textStatus, xhr) {
            //XMLの場合
            // $("#imagebox").attr("src", "data:image/jpeg:base64," + $(data).find("Image").eq(0).text());

            const v = $(data)[0];
            // for (let i in v.Data) {
            //     $("#imagebox2").append("<img src='data:image/png;base64," + v.Data[i].Image + "' />");
            // }

        }).fail(function (xhr, textStatus, errorThrown) {
            alert("NG");
            alert("status:" + xhr.status + "\n" +
                "textStatus:" + textStatus + "\n" +
                "errorThrown:" + errorThrown);
        });
    });

});