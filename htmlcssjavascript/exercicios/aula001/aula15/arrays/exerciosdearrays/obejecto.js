let amigo = {nome:'jose',sexo:'M',peso: 85.4,engodar(p=0){console.log('engordou')
    this.peso  += p
}}
amigo.engodar(2)
console.log(`${amigo.nome} para ${amigo.peso}`)