//Day 5 Challenge https://adventofcode.com/2020/day/5

open System.Collections.Generic;

//Seat record
type Seat = {
    mutable RowMin: double; 
    mutable RowMax: double; 
    mutable Row: double; 
    mutable ColMin: double; 
    mutable ColMax: double; 
    mutable Col: double; 
    mutable SeatId: double;
    }

let getSeatId seat =  8. * seat.Row + seat.Col

let getDefaultSeat =  
    let seat = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.; SeatId = 0.};
    seat

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
    seat.ColMax <- floor(seat.ColMax - move)
    seat.Col <- floor seat.ColMin
    seat

let parseBoardingPass (boardingCode:string, seat:Seat) =
    let mutable seat = seat
    for c in boardingCode.ToCharArray() do
        match c with 
        | 'B' -> seat <- moveBack seat 
        | 'F' -> seat <- moveForward seat 
        | 'R' -> seat <- moveRight seat
        | 'L' -> seat <- moveLeft seat
        | _ -> printfn "%A not valid" c
    seat

//// Sanity check cases
//let seat = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.};
//parseBoardingPass ("BFFFBBFRRR", seat)

//seat.SeatId

//let seat2 = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.};
//parseBoardingPass ("FFFBBBFRRR", seat2)

//seat2.SeatId

//let seat3 = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.};
//parseBoardingPass ("BBFFBBFRLL", seat3)

//seat3.SeatId

// Iterate over all the boarding pass lines and find the max seat.
let findMaxSeat boardingPassLines = 
    let mutable maxSeat = 0.;
    Seq.iter ( fun line ->  
        let defaultSeat = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.; SeatId = 0.};
        let mutable seat = parseBoardingPass (line, defaultSeat)
        seat.SeatId <- getSeatId seat  
        if seat.SeatId > maxSeat then maxSeat <- seat.SeatId
    ) boardingPassLines 

    maxSeat


// Iterate over all the boarding pass lines and find the missing seat.
let findMissingSeat boardingPassLines = 
    let mutable foundSeats = new HashSet<int>();
    Seq.iter ( fun line -> 
        let defaultSeat = {RowMin = 0.; RowMax = 127.; Row = 0.; ColMin = 0.; ColMax = 7.; Col = 0.; SeatId = 0.};
        let mutable seat = parseBoardingPass (line, defaultSeat)
        foundSeats.Add(int(getSeatId seat))  |> ignore
        ) boardingPassLines
        
    let maxSeatId= 959
    let mutable missingSeatId = 0
    for seatId in 0 .. maxSeatId do 
        if not (foundSeats.Contains (seatId)) then missingSeatId <- seatId

    missingSeatId


// Solve Problem 1: Determine the max seat
let boardingPassLines = System.IO.File.ReadLines(System.IO.Path.Combine(__SOURCE_DIRECTORY__ ,  @"Day5Problem1Input.txt"))
let maxSeat = findMaxSeat boardingPassLines
printfn "Max seat number is: %A" maxSeat

// Solve Problem 2: Determine the missing seat
let missingSeatId = findMissingSeat boardingPassLines
printfn "Missing Seat ID: %A" missingSeatId
