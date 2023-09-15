import express from "express";

import { addOneCoin } from "../controllers/coinsController.js";

const router = express.Router();

router
  .route("/")
  .post(addOneCoin);

  export default router;