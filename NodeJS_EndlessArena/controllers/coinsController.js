import { Coins } from "../models/Coins.js"; 

export async function addOneCoin(req, res) {
    if (!validationResult(req).isEmpty()) {
      res.status(400).json({ errors: validationResult(req).array() });
    } else {
      Coins.create({
        currentCoins: req.body.currentCoins,
      })
        .then((docs) => {
          res.status(200).json({
              message: "Added!",
              docs
          });
        })
        .catch((err) => {
          res.status(500).json({ error: err });
        });
    }
  }