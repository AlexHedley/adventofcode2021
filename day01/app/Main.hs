module Main where

import System.IO
import Data.List

readInt :: String -> Int
readInt = read

diff [] = []
diff ls = zipWith (-) (tail ls) ls

count list = sum $ map fromEnum list

main :: IO ()

main = do  
    contents <- readFile "input.txt"
    let items = map readInt . words $ contents
    -- print items -- [199,200,208,210,200,207,240,269,260,263]

    let result = zipWith (-) (tail items) items
    -- print result -- [1,8,2,-10,7,33,29,-9,3]
    
    let negs = map (<0) result
    -- print negs -- [False,False,False,True,False,False,False,True,False]
    let pos = map (>=0) result
    -- print pos -- [False,False,False,True,False,False,False,True,False]

    -- let occs = count negs -- 2
    let occs = count pos -- 7
    print occs
