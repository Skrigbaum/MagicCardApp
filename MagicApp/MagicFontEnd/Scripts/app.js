﻿

function Generate() {
    Creatures();
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
        success: function(Code) {

          return SaveCodes(Code)
           
        }
    });
    function SaveCodes(Code) {
        $("#Load").attr('value', Code);
        return null
    };
}

function Land() {
    Lands();
}

function Lands() {
    $.ajax({
        url: 'Home/Land',
        async: true,
        type: 'GET',
        success: function (ImgUrl) {

            LandUrl(ImgUrl);
            return ImgUrl;
        }

    });
    function LandUrl(ImgUrl) {
        $("#Land").attr('src', ImgUrl);
    };
}


function Creatures() {
    $.ajax({
        url: 'Home/Creature',
        async: true,
        type: 'GET',
        success: function(ImgUrl) {

            CreatureUrl(ImgUrl);
            return ImgUrl;
        }

    });
    function CreatureUrl(ImgUrl) {
        $("#Creature").attr('src', ImgUrl);
    };
}

function Helpers() {
    Helper();
}

function Helper() {
    $.ajax({
        url: 'Home/Helper',
        async: true,
        type: 'GET',
        success: function (ImgUrl) {

            HelperUrl(ImgUrl);
            return ImgUrl;
        }

    });
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
        $("#Antagonist").attr('src', ImgUrl);
    }
};

function Solutions() {
    Solution();
}

function Solution() {
    $.ajax({
        url: 'Home/Solution',
        async: true,
        type: 'GET',
        success: function (ImgUrl) {

            Solutionurl(ImgUrl);
            return ImgUrl;
        }

    });
    function Solutionurl(ImgUrl) {
        $("#Solution").attr('src', ImgUrl);
    }
};