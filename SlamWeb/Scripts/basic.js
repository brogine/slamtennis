

jQuery(function ($) {
$('#basic-modal .DATOS').click(function(e) {
$('#content-DATOS').modal();
		
		  return false;
	});
});

function MostrarInscripcion() {
    $('#content-DATOS').modal();
}

function MostrarBorrarInscripcion() {
    $('#BorrarIncrip').modal();
}
//jQuery(function($) {
//$('#basic-modal .BASICO').click(function(e) {
//    $('#content-BASICO').modal();

//        return false;
//    });
//});

//jQuery(function($) {
//$('#basic-modal .HOGAR').click(function(e) {
//    $('#content-HOGAR').modal();

//        return false;
//    });
//});

//jQuery(function($) {
//$('#basic-modal .EMPRESA').click(function(e) {
//$('#content-EMPRESA').modal();
//        return false;
//    });
//});
//jQuery(function($) {
//$('#basic-modal .PREMIUN').click(function(e) {
//    $('#content-PREMIUN').modal();
//        return false;
//    });
//});

//jQuery(function($) {
//$('#basic-modal .FULL').click(function(e) {
//    $('#content-FULL').modal();

//        return false;
//    });
//});

/*jQuery(function($) {
    $('#basic-modal .FULL').click(function(e) {
    if ($('#ctl00$ContentPlaceHolder1$TxtNombre').Value == "") {
            return false;
        }
        $('#content-FULL').modal();

        return false;
    });
});*/
function Wizard() {
    $('#content-Wizard').modal();
}