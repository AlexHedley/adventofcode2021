module Main where

import System.IO
import Data.List
-- import Data.String

readInt :: String -> Int
readInt = read

main :: IO ()

-- forward 5

main = do
    contents <- readFile "input.txt"
    let items = map . words $ contents
    -- let items = map . lines $ contents
    print items