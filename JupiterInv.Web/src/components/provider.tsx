'use client';

import {RecoilRoot} from "recoil";
import React from "react";

function Provider({ children }: { children: React.ReactNode }) {
    return <RecoilRoot>{children}</RecoilRoot>;
}

export default Provider;