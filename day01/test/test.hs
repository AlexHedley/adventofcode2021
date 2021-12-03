module Main (main) where

import Test.HUnit

test1 = TestCase $ assertEqual "test" "FOO" "FOO"

tests = TestList [TestLabel "test1" test1]

main :: IO ()
main = do
  runTestTT tests
  return ()