import React, { useEffect, useState } from "react";

import { Get } from "../../services/AdvertisingService";

const Index = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        get();
    }, []);

    const get = () => {
        const data = Get();
        setData(data);
    }

    return (<>
        Em desenvolvimento...
    </>);
}

export default Index;