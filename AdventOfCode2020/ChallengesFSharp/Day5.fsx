
//Day 5 Challenge https://adventofcode.com/2020/day/5

let rows = 128
let columns = 8

//Seat record
type Seat = {
    mutable RowMin: double; 
    mutable RowMax: double; 
    mutable Row: double; 
    mutable ColMin: double; 
    mutable ColMax: double; 
    mutable Col: double; 
    }
    with 
    member this.SeatId = 8. * this.Row + this.Col

let moveBack seat =
    let move = ceil(seat.RowMax - seat.RowMin)/2.
    seat.RowMin <- ceil(seat.RowMin + move)
    seat.Row <- ceil seat.RowMax
    seat

let moveForward seat =
    let move = floor(seat.RowMax - seat.RowMin)/2.
    seat.RowMax <- floor(seat.RowMax - move)
    seat.Row <- floor seat.RowMin
    seat

let moveRight seat =
    let move = ceil(seat.ColMax - seat.ColMin)/2.
    seat.ColMin <- ceil(seat.ColMin + move)
    seat.Col <- ceil seat.ColMax
    seat

let moveLeft seat =
    let move = floor(seat.ColMax - seat.ColMin)/2.
    seat.RowMax <- floor(seat.ColMax - move)
    seat.Col <- floor seat.ColMin
    seat

let parseBoardingPass (boardingCode:string, seat:Seat) =
    let mutable rowStep = rows
    let mutable seat = seat
    for c in boardingCode.ToCharArray() do
        match c with 
        | 'B' -> seat <- moveBack seat 
        | 'F' -> seat <- moveForward seat 
        | 'R' -> seat <- moveRight seat
        | 'L' -> seat <- moveLeft seat
        | _ -> printfn "%A not valid" c
       
       // printfn "%A: min:%A max:%A" c seat.RowMin seat.RowMax
       
    seat

let seat = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.};
parseBoardingPass ("BFFFBBFRRR", seat)

seat.SeatId

let seat2 = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.};
parseBoardingPass ("FFFBBBFRRR", seat2)

seat2.SeatId

let seat3 = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.};
parseBoardingPass ("BBFFBBFRLL", seat3)

seat3.SeatId
