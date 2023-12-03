module Main where

import System.IO
import Data.List
import Data.List.Split

readInt :: String -> Int
readInt = read

diff [] = []
diff ls = zipWith (-) (tail ls) ls

count list = sum $ map fromEnum list

for list action = mapM_ action list --https://stackoverflow.com/a/63839083/2895831

main :: IO ()

main = do  
    contents <- readFile "input.txt"
    let items = map readInt . words $ contents
    -- print items -- [199,200,208,210,200,207,240,269,260,263]

    let spl = chunksOf 3 [4,1,6,1,7,3,5,3,9] -- [4,1,6][1,7,3][5,3,9] --splitEvery
    print spl

    -- for items (\ i -> do
    --     print(i^2)
    --    )

    for items.length (\ i -> do
        print i
        let x = chunksOf 3 items
        print x
        )
