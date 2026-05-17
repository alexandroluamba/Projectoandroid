let canvas = document.querySelector("canvas")
let ctx = canvas.getContext("2d")
let h1 = document.querySelector("h1#msg")
let size = 30

let snake=[
    {x:270,y:240}
    
   
]

let diriction, loopid
 
let drawSnake = () => {
    ctx.fillStyle = "#ddd"
    
    snake.forEach((posiction,index) => {
        if (index== snake.length -1){
             ctx.fillStyle = "#011"
        }

        ctx.fillRect(posiction.x,posiction.y,size,size)
    })
}
let movesnake = () =>{
    if (!diriction) return

    let head = snake[snake.length -1]

    snake.shift()
    if (diriction == "right"){
        snake.push({x: head.x + size, y: head.y})
    
    }
    if (diriction == "left"){
        snake.push({x: head.x - size, y: head.y})
    
    }
    if (diriction == "down"){
        snake.push({x: head.x , y: head.y + size})
    
    }
    if (diriction == "up"){
        snake.push({x: head.x, y: head.y - size})
    
    }
}
gameloop = () =>{
    clearInterval(loopid)
    ctx.clearRect(0,0,600,600)
    drawSnake()
    movesnake()

    loopid = setTimeout(()=>{
        gameloop()
     },300)
 
}
gameloop()

document.addEventListener("keydown", ({key}) => {
    if(key == "ArrowRight" && diriction != "left"){
        diriction = "right"
    }
    if(key == "ArrowLeft" && diriction != "right"){
        diriction = "left"
    }
    if(key == "ArrowDown" && diriction != "up"){
        diriction = "down"
    }
    if(key == "ArrowUp" && diriction != "down"){
        diriction = "up"
    }
})

