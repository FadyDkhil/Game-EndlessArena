import { Long } from "bson";
import mongoose from "mongoose";
const { Schema, model } = mongoose;

const coinsSchema = new Schema({
  Name: { type: Number },
});

const Coins = mongoose.model("coins", coinsSchema);

export { Coins };
