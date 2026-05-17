function carregar() {
    var msg = window.document.querySelector('div#msg')
    var img = window.document.getElementById('imagem')
    var data = new Date()
    var hora = data.getUTCHours()
    
    msg.innerHTML = `Agora sao ${hora} horas.`
    
    if (hora >= 12 && hora < 12){
       img.src = 'tarde.png'
    }

    
}

