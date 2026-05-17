function compliar(){
    var mensagem = window.document.getElementById('msg')
    var imag = window.document.getElementById('imagem')
    var data = new Date()
    var Hora = 4 
     //var Hora = data.getHours()
    var min = data.getMinutes()
    
    mensagem.innerHTML = `Agora são <strong>${Hora}:${min}</strong> horas`
   
    if (Hora < 12){
        imag.src = 'manha.png'
    }else if (Hora >= 12 && Hora < 18) {
          imag.src = 'imhboa2.png'
    }
    else{
        imag.src = 'noite2.png'
    }
}