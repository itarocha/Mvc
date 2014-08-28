// foi injetado um array json no formato
// array['m/d/yyyy',{nome:''}]

$(function(){
    var ANO_ATUAL = 0;
    //var datas_especiais = {};

    $('#dates').datepicker({
        dateFormat: 'yy-mm-dd',
        inline: true,
        dayNamesMin: ['DOMINGO', 'SEGUNDA', 'TERÇA', 'QUARTA', 'QUINTA', 'SEXTA', 'SÁBADO'],
        monthNamesShort: ['Janeiro','Fevereiro','Março','Abril','Maio','Junho','Julho','Agosto','Setembro','Outubro','Novembro','Dezembro'],
        monthNames: ['Janeiro', 'Fevereiro', 'Marco', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        changeMonth: false,
        changeYear: false,
        /*
        onSelect: function(dateText, inst){
            
            var theDate = new Date(Date.parse($(this).datepicker('getDate')));
            var m = theDate.getMonth()+1;
            var d = theDate.getDate();
            var y = theDate.getFullYear();
            
            var classe = '.dta'+dateText;
            
            if ($(classe).length){
                $('.dta').hide();
                $(classe).show();
            } else {
                $.post(LINK_CONTROLLER + '/ajaxbuscadata', {
                    "dta": dateText,
                    "d": d,
                    "m": m,
                    "y": y
                }, function(t) {
                    $('.dta').hide();
                    $('.calendario-destaque').append(t);
                });
            }
        },
        onChangeMonthYear: function(year, month, inst){
            if (ANO_ATUAL != year) {
                ANO_ATUAL = year;
                ChangeYear(year, month);
            } else {
                ChangeMonthYear(year,month);
            }
        },
        beforeShowDay: function(date) {
            var event = getEventoDia(date);
            if (event) {
                return [true, 'entrevistaagendadas', event.titulo];
            }
            else {
                return [true, '', ''];
            }
        }
        */
    });
    
    // Após configurar o datepicker, setar a variável global ANO_ATUAL com o ano do datePicker
    var selectedDate = $('#dates').datepicker( "getDate" );
    ANO_ATUAL = selectedDate.getFullYear();
    // Carrega as datas comemorativas do mês atual
    ChangeMonthYear(ANO_ATUAL,selectedDate.getMonth()+1);

    // Carrega os eventos através de uma chamada AJAX/JSON.
    function ChangeYear(year, month){
        calendario = {};

        $.post(LINK_MODULE + "calendario/ajaxbuscarcalendario", {
               "year": year
           }, function(data){
               calendario = data;
               ChangeMonthYear(year,month);
               $('#dates').datepicker( "refresh" );
           }, "json");
    }
            
    // Carrega os eventos através de uma chamada AJAX/JSON.            
    function ChangeMonthYear(year,month){
        var lista = calendario[month];
        var data = '';
        if (lista) {
            $('.calendario-ul').html(lista);
            $.each(lista, function (index, evento) {
                $.each(evento, function(i, e){
                    data = data +
                    '<li class="calendario-li">'+
                    '    <img src="'+URL_UPLOAD+'calendario/130x60-'+e.foto+'" alt="NomeImagem" class="home-data-content-img" />'+
                    '    <div class="home-data-content-data">'+e.dia_mes+'</div>'+
                    '    <div class="home-data-content-dia">'+e.titulo+'</div>'+
                    '</li>';
                });
            });
        }
        $('.calendario-ul').html(data);
    }

    function getEventoDia(date){
        var m = date.getMonth()+1;
        var mmdd = $.datepicker.formatDate("mmdd",date);
        
        var obj = null;
        var retorno = calendario[m];
        if (retorno) {
            var evento = retorno[mmdd];
            if (evento){
                // Loop para mostrar títulos
                obj = {dia_mes:evento[0].dia_mes, titulo: evento[0].dia_mes+' - '};
                $.each(evento, function(i,e){
                    obj.titulo = obj.titulo+e.titulo+'\n';
                });
            }
        }
        return obj;
    }    
 });
 
