# Day 22
# Crab combat
# There's two players in a card game. 
# https://adventofcode.com/2020/day/22
# Quoted from above: "The game consists of a series of rounds: both players draw their top card, 
# and the player with the higher-valued card wins the round. The winner keeps 
# both cards, placing them on the bottom of their own deck so that the winner's 
# card is above the other card. If this causes a player to have all of the cards, 
# they win, and the game ends."

# This tells me that we need two mutable collections to be able to hold each 
# player's cards. We compare the top two cards in each iteration, and move them 
# according to the rules above. 

# Looks like a deque would be good to try for this: https://docs.python.org/3/library/collections.html#collections.deque


# Example.
import collections
from collections import deque

# Set up each player's cards
player1 = deque([9,2,6,3,1])
player2 = deque([5, 8, 4, 7, 10])

def runGame():
    while (len(player1) and len(player2)):
        p1Card = player1.popleft()
        p2Card = player2.popleft()
        if (p1Card > p2Card):
            player1.append(p1Card)
            player1.append(p2Card)
        
        if (p2Card > p1Card):
            player2.append(p2Card)
            player2.append(p1Card)
        
        # print (f"{player1}")
        # print (f"{player2}")

# Score is computed from the RHS, and is the cumulative total of each card * position
def computeScore(player):
    score = 0
    count = 1
    while (len(player)):
        card = player.pop()        
        score += card*count
        count += 1
    return score

print ("\nExample solution:\n")
runGame()
#Check which player is the winner
if (len(player1)):
    score = computeScore(player1)
    print (f"Player 1 is the winner, with score: {score}")

#Check which player is the winner
if (len(player2)):
    score = computeScore(player2)
    print (f"Player 2 is the winner, with score: {score}")


# Solve part 1
print ("Part1 solution:\n")
print ("Starting decks:")
player1 = deque([41,26,29,11,50,38,42,20,13,9,40,43,10,24,35,30,23,15,31,48,27,44,16,12,14])
print (f"{player1}")

player2 = deque([18,6,32,37,25,21,33,28,7,8,45,46,49,5,19,2,39,4,17,3,22,1,34,36,47])
print (f"{player2}")

runGame()

#Check which player is the winner
if (len(player1)):
    score = computeScore(player1)
    print (f"Player 1 is the winner, with score: {score}")

#Check which player is the winner
if (len(player2)):
    score = computeScore(player2)
    print (f"Player 2 is the winner, with score: {score}")
