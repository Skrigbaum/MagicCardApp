

function Generate() {
    Problem();
    Land();
    Helper();
    Solution();
    Antagonists();
}


function SaveCards() {
    $.ajax({
        url: 'Home/Save',
        async: true,
        type: 'GET',
        success: function (Code) {

            return SaveCodes(Code)

        }
    });
    function SaveCodes(Code) {
        $("#Load").prop('value', Code);

        return null
    };
}

function LoadCards() {
    $.ajax({
        url: 'Home/Load',
        async: true,
        type: 'POST',
        dataType: "JSon",
        data: { "codes": $("#Load").val().toString() },
        success: function (data) {
            LoadCodes(data)
            return null
        }
    });
    function LoadCodes(data) {
        var imgurl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid="
        var imgendurl = "&type=card";
        $("#Problem").attr('src', imgurl + data[0] + imgendurl);
        $("#Land").attr('src', imgurl + data[1] + imgendurl);
        $("#Solution").attr('src', imgurl + data[2] + imgendurl);
        $("#Helper").attr('src', imgurl + data[3] + imgendurl);
        $("#Antagonist").attr('src', imgurl + data[4] + imgendurl);
        return null;
    };
}

function Land() {
    Lands();
}
function Lands() {
    if ($("#SettingLock").prop('checked')) {
        return null;
    }
    else {
        $.ajax({
            url: 'Home/Land',
            async: true,
            type: 'GET',
            success: function (ImgUrl) {

                LandUrl(ImgUrl);
                return ImgUrl;
            }

        })
    };
    function LandUrl(ImgUrl) {


        $("#Land").attr('src', ImgUrl);

    };
}

function Problems() {
    Problem();
}
function Problem() {
    if ($("#ProblemLock").prop('checked')) {
        return null;
    }
    else {
        $.ajax({
            url: 'Home/Creature',
            async: true,
            type: 'GET',
            success: function (ImgUrl) {

                ProblemUrl(ImgUrl);
                return ImgUrl;
            }

        })
    };
    function ProblemUrl(ImgUrl) {


        $("#Problem").attr('src', ImgUrl);
       

    };
}

function Helpers() {
    Helper();
}
function Helper() {
    if ($("#HelperLock").prop('checked')) {
        return null;
    }
    else {


        $.ajax({
            url: 'Home/Helper',
            async: true,
            type: 'GET',
            success: function (ImgUrl) {

                HelperUrl(ImgUrl);
                return ImgUrl;
            }

        })
    };
    function HelperUrl(ImgUrl) {


        $("#Helper").attr('src', ImgUrl);

    }
};

function Antagonists() {
    Antagonist();
}
function Antagonist() {
    $.ajax({
        url: 'Home/Antagonist',
        async: true,
        type: 'GET',
        success: function (ImgUrl) {

            AntUrl(ImgUrl);
            return ImgUrl;
        }

    });
    function AntUrl(ImgUrl) {
        if ($("#AntagonistLock").prop('checked')) {
            return null;
        }
        else {
            $("#Antagonist").attr('src', ImgUrl);
        }
    }
};

function Solutions() {
    Solution();
}
function Solution() {
    if ($("#SolutionLock").prop('checked')) {
        return null;
    }
    else {
        $.ajax({
            url: 'Home/Solution',
            async: true,
            type: 'GET',
            success: function (ImgUrl) {

                Solutionurl(ImgUrl);
                return ImgUrl;
            }

        })
    };
    function Solutionurl(ImgUrl) {
        $("#Solution").attr('src', ImgUrl);

    }
};