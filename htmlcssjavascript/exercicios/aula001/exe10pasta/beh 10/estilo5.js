function gerar(){
    
    
    let recebe = document.getElementById("recebe")
    let aparecer = document.getElementById("aprecenatelaaqui")
    if (recebe.value.length == 0){
        window.alert("Erroooooooooo!")
    }else{
    let v = Number(recebe.value)

    let f = 1
    
       for (let c=v; c>1;c--){
            let item = document.createElement('option')
            
            item.text = `${v}!= ${c} = ${f *= c}`
            aparecer.appendChild(item)
            
            
    

        }
        
        
      }
    
    }
